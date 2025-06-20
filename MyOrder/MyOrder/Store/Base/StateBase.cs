namespace MyOrder.Store.Base;

public abstract record StateBase(
    bool Initialized = false,
    bool IsLoading = false,
    bool IsFaulted = false,
    string ErrorMessage = "");