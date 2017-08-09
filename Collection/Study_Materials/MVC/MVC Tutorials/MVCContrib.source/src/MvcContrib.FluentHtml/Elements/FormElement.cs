using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Mvc;
using MvcContrib.FluentHtml.Behaviors;
using MvcContrib.FluentHtml.Html;

namespace MvcContrib.FluentHtml.Elements
{
	/// <summary>
	/// Base class for form elements.
	/// </summary>
	/// <typeparam name="T">Derived type</typeparam>
	public abstract class FormElement<T> : DisableableElement<T> where T : FormElement<T>, IElement
	{
		protected FormElement(string tag, string name, MemberExpression forMember, IEnumerable<IBehaviorMarker> behaviors)
			: base(tag, forMember, behaviors)
		{
			SetName(name);
		}

		protected FormElement(string tag, string name) : base(tag)
		{
			SetName(name);
		}

		public override string ToString()
		{
			InferIdFromName();
			return base.ToString();
		}

		/// <summary>
		/// Determines how the HTML element is closed.
		/// </summary>
		public override TagRenderMode TagRenderMode
		{
			get { return TagRenderMode.SelfClosing; }
		}

		protected virtual void InferIdFromName()
		{
			if (!builder.Attributes.ContainsKey(HtmlAttribute.Id))
			{
				Attr(HtmlAttribute.Id, builder.Attributes[HtmlAttribute.Name].FormatAsHtmlId());
			}
		}

		protected void SetName(string name)
		{
			SetAttr(HtmlAttribute.Name, name);
		}
	}
}