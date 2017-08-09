
namespace Dashboard.Interfaces
{
    public interface IModel
    {
        void RegisterPresenter(IPresenter presenter);
        void UnRegisterPresenter(IPresenter presenter);
        void NotifyPresenters(IMessage msg);
    }
}
