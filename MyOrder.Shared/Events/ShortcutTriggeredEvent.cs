namespace MyOrder.Shared.Events;

public enum Shortcut
{
    F5,
    CtrlI
}

public record ShortcutTriggeredEvent(Shortcut Shortcut);