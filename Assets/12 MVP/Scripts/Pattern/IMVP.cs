

using System;

public interface IModel
{
    public string ModelName { get; set; }
}

public interface IPresenter
{
    public IModel Model { get; }

    public IView View { get; }
}


public interface IView
{
    public IPresenter Presenter { get; }

}