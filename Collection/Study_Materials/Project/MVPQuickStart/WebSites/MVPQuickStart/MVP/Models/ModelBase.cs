using System.Collections.Generic;
using Dashboard.Interfaces;

namespace Dashboard.Models
{
    public abstract class ModelBase : IModel
    {
        private readonly List<IPresenter> _registeredPresenters;

        protected ModelBase()
        {
            _registeredPresenters = new List<IPresenter>();
        }

        public void RegisterPresenter(IPresenter presenter)
        {
            if (!_registeredPresenters.Contains(presenter))
            {
                _registeredPresenters.Add(presenter);
            }
        }

        public void UnRegisterPresenter(IPresenter presenter)
        {
            _registeredPresenters.Remove(presenter);
        }

        public void NotifyPresenters(IMessage msg)
        {
            foreach (IPresenter p in _registeredPresenters)
            {
                p.RecieveNotice(msg);
            }
        }
    }
}
