namespace Backend.Services;

public interface IServiceBase
{
    public ILogger Logger { get; }

    public Task RunAsync();
}

public interface IServiceBase<I, O>
{   
    public ILogger Logger { get; }
   
    public Task<O> RunAsync(I data);
}

