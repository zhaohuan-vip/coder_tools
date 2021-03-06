﻿namespace CT.Entity
{
    public class TextString
    {
        public TextString()
        {

        }
        private string _word;

        /// <summary>
        /// Gets or sets the word.
        /// </summary>
        /// <value>The word.</value>
        public string Word
        {
            get
            {
                return _word;
            }
            set { _word = value; }
        }

        /// <summary>
        /// 是否去空格
        /// </summary>
        /// <value><c>true</c> if this instance is tirm; otherwise, <c>false</c>.</value>
        public bool IsTirm { get; set; }

        /// <summary>
        /// 设置获取大小写0:正常,1:大写,2:小写
        /// </summary>
        /// <value></value>
        public CTEnum UpperOrLower { get; set; }
        
    }


}