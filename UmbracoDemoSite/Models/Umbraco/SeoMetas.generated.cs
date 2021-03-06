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
	// Mixin content Type 2159 with alias "seoMetas"
	/// <summary>Seo Metas</summary>
	public partial interface ISeoMetas : IPublishedContent
	{
		/// <summary>Description</summary>
		string Description { get; }

		/// <summary>Tilte</summary>
		string Tilte { get; }

		/// <summary>Url Alias</summary>
		string UmbracoUrlAlias { get; }
	}

	/// <summary>Seo Metas</summary>
	[PublishedContentModel("seoMetas")]
	public partial class SeoMetas : PublishedContentModel, ISeoMetas
	{
#pragma warning disable 0109 // new is redundant
		public new const string ModelTypeAlias = "seoMetas";
		public new const PublishedItemType ModelItemType = PublishedItemType.Content;
#pragma warning restore 0109

		public SeoMetas(IPublishedContent content)
			: base(content)
		{ }

#pragma warning disable 0109 // new is redundant
		public new static PublishedContentType GetModelContentType()
		{
			return PublishedContentType.Get(ModelItemType, ModelTypeAlias);
		}
#pragma warning restore 0109

		public static PublishedPropertyType GetModelPropertyType<TValue>(Expression<Func<SeoMetas, TValue>> selector)
		{
			return PublishedContentModelUtility.GetModelPropertyType(GetModelContentType(), selector);
		}

		///<summary>
		/// Description
		///</summary>
		[ImplementPropertyType("description")]
		public string Description
		{
			get { return GetDescription(this); }
		}

		/// <summary>Static getter for Description</summary>
		public static string GetDescription(ISeoMetas that) { return that.GetPropertyValue<string>("description"); }

		///<summary>
		/// Tilte
		///</summary>
		[ImplementPropertyType("tilte")]
		public string Tilte
		{
			get { return GetTilte(this); }
		}

		/// <summary>Static getter for Tilte</summary>
		public static string GetTilte(ISeoMetas that) { return that.GetPropertyValue<string>("tilte"); }

		///<summary>
		/// Url Alias: Enter an alternative url
		///</summary>
		[ImplementPropertyType("umbracoUrlAlias")]
		public string UmbracoUrlAlias
		{
			get { return GetUmbracoUrlAlias(this); }
		}

		/// <summary>Static getter for Url Alias</summary>
		public static string GetUmbracoUrlAlias(ISeoMetas that) { return that.GetPropertyValue<string>("umbracoUrlAlias"); }
	}
}
