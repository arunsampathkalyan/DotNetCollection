using System;
using Microsoft.Practices.ObjectBuilder;

namespace MVPQuickStart.Shell.Views
{
	public partial class LoadDocument : Microsoft.Practices.CompositeWeb.Web.UI.Page, ILoadDocumentView
	{
		private LoadDocumentPresenter _presenter;

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!this.IsPostBack)
			{
				this._presenter.OnViewInitialized();
			}
			this._presenter.OnViewLoaded();
		}

		[CreateNew]
		public LoadDocumentPresenter Presenter
		{
			get
			{
				return this._presenter;
			}
			set
			{
				if(value == null)
					throw new ArgumentNullException("value");

				this._presenter = value;
				this._presenter.View = this;
			}
		}

		// TODO: Forward events to the presenter and show state to the user.
		// For examples of this, see the View-Presenter (with Application Controller) QuickStart:
		//	

	}
}

