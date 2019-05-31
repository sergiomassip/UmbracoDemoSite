//------------------------------------------------------------------------------
// <auto-generated>
//   This code was generated by a tool.
//
//    Umbraco.ModelsBuilder v3.0.10.102
//
//   Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web;
using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using Umbraco.ModelsBuilder;
using Umbraco.ModelsBuilder.Umbraco;

namespace UmbracoDemoSite.Models.Umbraco
{
	/// <summary>Category</summary>
	[PublishedContentModel("category")]
	public partial class Category : PublishedContentModel
	{
#pragma warning disable 0109 // new is redundant
		public new const string ModelTypeAlias = "category";
		public new const PublishedItemType ModelItemType = PublishedItemType.Content;
#pragma warning restore 0109

		public Category(IPublishedContent content)
			: base(content)
		{ }

#pragma warning disable 0109 // new is redundant
		public new static PublishedContentType GetModelContentType()
		{
			return PublishedContentType.Get(ModelItemType, ModelTypeAlias);
		}
#pragma warning restore 0109

		public static PublishedPropertyType GetModelPropertyType<TValue>(Expression<Func<Category, TValue>> selector)
		{
			return PublishedContentModelUtility.GetModelPropertyType(GetModelContentType(), selector);
		}

		///<summary>
		/// Category Menu
		///</summary>
		[ImplementPropertyType("categoryMenu")]
		public IEnumerable<IPublishedContent> CategoryMenu
		{
			get { return this.GetPropertyValue<IEnumerable<IPublishedContent>>("categoryMenu"); }
		}

		///<summary>
		/// Catergory Name
		///</summary>
		[ImplementPropertyType("catergoryName")]
		public string CatergoryName
		{
			get { return this.GetPropertyValue<string>("catergoryName"); }
		}
	}
}