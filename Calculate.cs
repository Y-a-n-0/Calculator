using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Emit;
using System.Windows.Controls;

namespace Calculator
{
    internal class Calculate
    {
        public Calculate()
        {
            m_status_now_ = m_status_.kInFirstNum;
            m_str_firstnum_ = string.Empty;
            m_str_secondnum_ = string.Empty;
            m_symbolpressed_ = string.Empty;
            m_result_ = 0;
        }

        public string m_symbolpressed_ = "";
        public string m_str_firstnum_ = "";      //字符串-第一个输入的数字
        public string m_str_secondnum_ = "";     //字符串-第二个输入的数字
        public float m_firstnum_;           //第一个输入的数字
        public float m_secondnum_;          //第二个输入的数字
        public float m_result_;             //两数运算结果
        public m_status_ m_status_now_;
        public System.Windows.Controls.Label m_label_result_;
        public System.Windows.Controls.Label m_label_symbol;
        public enum m_status_
        {
            kInFirstNum,
            kInSecondNum,
            kEqualPressed
        }

        //注册Label控件
        public void RegisterLabel(System.Windows.Controls.Label result, System.Windows.Controls.Label symbol)
        {
            m_label_result_ = result;
            m_label_symbol = symbol;
        }

        //"="号按下
        public void PressEqual()
        {
            if (m_str_secondnum_ == string.Empty)
                return;
            m_status_now_ = m_status_.kEqualPressed;
        }

        //清空全部
        public void ClearAll()
        {
            m_label_result_.Content = "";
            m_label_symbol.Content = "";
            m_str_firstnum_ = string.Empty;
            m_str_secondnum_ = string.Empty;
            m_symbolpressed_ = string.Empty;
            m_status_now_ = m_status_.kInFirstNum;
            m_result_ = 0;
        }

        //绘制数字
        public void DrawNumbers()
        {

            switch (m_status_now_)
            {
                case m_status_.kInFirstNum:
                    m_label_result_.Content = m_str_firstnum_;




                    break;
                case m_status_.kInSecondNum:
                    m_label_result_.Content = m_str_secondnum_;
                    m_label_symbol.Content = $"{m_str_firstnum_} {m_symbolpressed_}";



                    break;
                case m_status_.kEqualPressed:
                    m_label_result_.Content = string.Empty;
                    switch (m_symbolpressed_)
                    {
                        case "+":
                            m_result_ = Convert.ToSingle(m_str_firstnum_) + Convert.ToSingle(m_str_secondnum_ == "" ? 0 : m_str_secondnum_);
                            break;
                        case "-":
                            m_result_ = Convert.ToSingle(m_str_firstnum_) - Convert.ToSingle(m_str_secondnum_ == "" ? 0 : m_str_secondnum_);
                            break;
                        case "÷":
                            m_result_ = Convert.ToSingle(m_str_firstnum_) / Convert.ToSingle(m_str_secondnum_ == "" ? 1 : m_str_secondnum_);
                            break;
                        case "×":
                            m_result_ = Convert.ToSingle(m_str_firstnum_) * Convert.ToSingle(m_str_secondnum_ == "" ? 1 : m_str_secondnum_);
                            break;
                        default:
                            break;
                    }
                    if (m_str_secondnum_.Substring(0, 1) == "-")
                        m_label_symbol.Content = $"{m_str_firstnum_} {m_symbolpressed_} ( {m_str_secondnum_} ) =\n{m_result_}";
                    else
                        m_label_symbol.Content = $"{m_str_firstnum_} {m_symbolpressed_} {m_str_secondnum_} =\n{m_result_}";


                    break;
                default:
                    break;
            }
        }

        //按下转换符
        public void PressedFunctionKeys(string val)
        {
            float tempnum = 0;
            if ((string)m_label_result_.Content == "")
                return;
            switch (m_status_now_)
            {
                case m_status_.kInFirstNum:
                    switch (val)
                    {
                        case "%":
                            tempnum = Convert.ToSingle(m_str_firstnum_);
                            tempnum /= 100;
                            m_str_firstnum_ = tempnum.ToString();
                            break;

                        case "+/-":
                            m_str_firstnum_ = m_str_firstnum_.Substring(0, 1) == "-" ? m_str_firstnum_.Substring(1) : "-" + m_str_firstnum_;
                            break;

                        case "del":
                            m_str_firstnum_ = m_str_firstnum_==""? m_str_firstnum_ : m_str_firstnum_.Substring(0,m_str_firstnum_.Length-1);
                            break;
                        default:
                            break;
                    }
                    break;
                case m_status_.kInSecondNum:
                    switch (val)
                    {
                        case "%":
                            tempnum = Convert.ToSingle(m_str_secondnum_);
                            tempnum /= 100;
                            m_str_secondnum_ = tempnum.ToString();
                            break;

                        case "+/-":
                            m_str_secondnum_ = m_str_secondnum_.Substring(0, 1) == "-" ? m_str_secondnum_.Substring(1) : "-" + m_str_secondnum_;
                            break;

                        case "del":
                            m_str_secondnum_ = m_str_secondnum_ == "" ? m_str_secondnum_ : m_str_secondnum_.Substring(0, m_str_secondnum_.Length - 1);
                            break;

                        default:
                            break;
                    }
                    break;
                case m_status_.kEqualPressed:
                    return;
                default:
                    break;
            }
        }

        //按下数字
        public void PressNums(string val)
        {
            if (m_status_now_ == m_status_.kInFirstNum && val == "0" && m_str_firstnum_ == "")
            {
                return;
            }
            switch (m_status_now_)
            {
                case m_status_.kInFirstNum:
                    m_str_firstnum_ += val;
                    break;
                case m_status_.kInSecondNum:
                    m_str_secondnum_ += val;
                    break;
                case m_status_.kEqualPressed:
                    m_str_secondnum_ = "";
                    m_str_firstnum_ = m_result_.ToString();
                    m_str_secondnum_ += val;
                    m_status_now_ = m_status_.kInSecondNum;
                    break;
                default:
                    break;
            }
        }

        //按下运算符
        public void PressSymbol(string val)
        {
            if (m_str_firstnum_ == "")
                return;
            if (m_status_now_ == m_status_.kEqualPressed)
            {
                m_status_now_ = m_status_.kInSecondNum;
                m_str_firstnum_ = m_result_.ToString();
                m_str_secondnum_ = string.Empty;
            }

            switch (m_status_now_)
            {
                case m_status_.kInFirstNum:
                    m_symbolpressed_ = val;
                    m_status_now_ = m_status_.kInSecondNum;



                    break;
                case m_status_.kInSecondNum:


                    switch (m_symbolpressed_)
                    {
                        case "+":
                            m_firstnum_ = Convert.ToSingle(m_str_firstnum_) + Convert.ToSingle(m_str_secondnum_ == "" ? 0 : m_str_secondnum_);
                            m_str_firstnum_ = m_firstnum_.ToString();

                            break;
                        case "-":
                            m_firstnum_ = Convert.ToSingle(m_str_firstnum_) - Convert.ToSingle(m_str_secondnum_ == "" ? 0 : m_str_secondnum_);
                            m_str_firstnum_ = m_firstnum_.ToString();

                            break;
                        case "÷":
                            m_firstnum_ = Convert.ToSingle(m_str_firstnum_) / Convert.ToSingle(m_str_secondnum_ == "" ? 1 : m_str_secondnum_);
                            m_str_firstnum_ = m_firstnum_.ToString();

                            break;
                        case "×":
                            m_firstnum_ = Convert.ToSingle(m_str_firstnum_) * Convert.ToSingle(m_str_secondnum_ == "" ? 1 : m_str_secondnum_);
                            m_str_firstnum_ = m_firstnum_.ToString();

                            break;
                        default:
                            break;
                    }
                    m_str_secondnum_ = string.Empty;
                    m_symbolpressed_ = val;




                    break;
                default:
                    break;
            }


        }

    }
}
