// Type: Microsoft.Practices.CompositeWeb.Presenter`1
// Assembly: Microsoft.Practices.CompositeWeb, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// Assembly location: D:\Karthik.sakkarai\karthik.sakkarai\Study_Materials\Project\MVPQuickStart\Library\Microsoft.Practices.CompositeWeb.dll

namespace Microsoft.Practices.CompositeWeb
{
    public abstract class Presenter<TView>
    {
        public TView View { get; set; }
        public virtual void OnViewInitialized();
        public virtual void OnViewLoaded();
    }
}
