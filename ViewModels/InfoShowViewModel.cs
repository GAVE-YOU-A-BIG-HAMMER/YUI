using Prism.Mvvm;
using Prism.Events;
using System;
using System.Collections.ObjectModel;
using System.Windows.Media;
using System.Windows;

namespace YControlLibrary;

public enum MessageLevel
{
    Info,
    Warning,
    Error
}
public class InfoShowViewModel : BindableBase
{
    private readonly IEventAggregator _eventAggregator;
    private const int MaxMessages = 500;

    public ObservableCollection<InfoMessage> Messages { get; } = new ObservableCollection<InfoMessage>();

    public InfoShowViewModel(IEventAggregator eventAggregator)
    {
        //_eventAggregator = ContainerLocator.Container.Resolve<IEventAggregator>();
        _eventAggregator = eventAggregator;
        _eventAggregator.GetEvent<InfoMessageEvent>().Subscribe(OnInfoMessageReceived);
        _eventAggregator.GetEvent<InfoMessageEvent>().Publish(("Hello, World!", MessageLevel.Info));
    }

    private void OnInfoMessageReceived((string text, MessageLevel level) message)
    {
        var infoMessage = new InfoMessage
        {
            Timestamp = DateTime.Now,
            Text = message.text,
            Level = message.level,
            Color = GetColorByLevel(message.level)
        };

        Application.Current.Dispatcher.Invoke(() =>
        {
            if (Messages.Count >= MaxMessages)
            {
                Messages.RemoveAt(Messages.Count);
            }

            Messages.Insert(0, infoMessage);
        });
    }

    private Brush GetColorByLevel(MessageLevel level)
    {
        return level switch
        {
            MessageLevel.Error => Brushes.Red,
            MessageLevel.Warning => Brushes.Orange,
            MessageLevel.Info => Brushes.Green,
            _ => Brushes.Black,
        };
    }
}

public class InfoMessage
{
    public DateTime Timestamp { get; set; }
    public string Text { get; set; }
    public MessageLevel Level { get; set; }
    public Brush Color { get; set; }
}

public class InfoMessageEvent : PubSubEvent<(string text, MessageLevel level)> { }
