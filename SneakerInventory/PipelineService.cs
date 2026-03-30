namespace SneakerInventory;

public class PipelineService
{
    private List<Action<Sneaker>> _steps;

    public PipelineService()
    {
        _steps = new List<Action<Sneaker>>();;
    }

    public void Use(Action<Sneaker> step)
    {
        _steps.Add(step);
    }

    public void Execute(Sneaker sneaker)
    {
        foreach (var step in _steps)
        {
            step(sneaker);
        }
        
    }
}