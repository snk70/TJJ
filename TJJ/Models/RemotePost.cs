using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Web;

namespace RemotePostData
{
    public class RemotePost
    {
        #region Fields
        private NameValueCollection inputValues;

        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets a remote URL
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets a method
        /// </summary>
        public string Method { get; set; }

        /// <summary>
        /// Gets or sets a form name
        /// </summary>
        public string FormName { get; set; }

        private NameValueCollection Params
        {
            get
            {
                return inputValues;
            }
        }

        #endregion

        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="url"> Remote page url</param>
        public RemotePost(string url)
        {
            inputValues = new NameValueCollection();
            Url = url;
            Method = "post";
            FormName = "formName";
        }
        #endregion

        #region Methods
        /// <summary>
        /// Adds the specified key and value to the dictionary (to be posted).
        /// </summary>
        /// <param name="name">The key of the element to add</param>
        /// <param name="value">The value of the element to add.</param>
        public void Add(string name, string value)
        {
            inputValues.Add(name, value);
        }

        /// <summary>
        /// Post
        /// </summary>
        public void Post()
        {
            var context = HttpContext.Current;
            context.Response.Clear();
            context.Response.Write("<html><head>");
            context.Response.Write(string.Format("</head><body onload=\"document.{0}.submit()\">", FormName));
            context.Response.Write(string.Format("<form name=\"{0}\" method=\"{1}\" action=\"{2}\" >", FormName, Method, Url));

            for (int i = 0; i < Params.Count; i++)
                context.Response.Write(string.Format("<input name=\"{0}\" type=\"hidden\" value=\"{1}\">", HttpUtility.HtmlEncode(Params.Keys[i]), HttpUtility.HtmlEncode(Params[Params.Keys[i]])));

            context.Response.Write("</form>");
            context.Response.Write("</body></html>");
            context.Response.End();
        }
        #endregion
    }

}