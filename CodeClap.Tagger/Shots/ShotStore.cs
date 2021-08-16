using System.Collections.Concurrent;

namespace CodeClap.Tagger.Shots;
public class ShotStore
{
    private readonly ConcurrentDictionary<Guid, Shot> _store = new ();

    public ShotStore()
    {
        var now = DateTimeOffset.Now;
        var items = new List<Shot>
        {
            new Shot(Guid.NewGuid(), "Jamie", "Tinyhawk Freestyle", now.AddMinutes(-15), new Location(0, 0)),
            new Shot(Guid.NewGuid(), "Dominic", "Marmotte 5\"", now.AddHours(-3), new Location(0, 0)),
            new Shot(Guid.NewGuid(), "Manu", "GTR Something", now.AddDays(-2), new Location(0, 0)),
            new Shot(Guid.NewGuid(), "Dominic", "Rubberduck-shaped quad", now.AddDays(-7), new Location(0, 0))
        };

        items.ForEach(shot => _store.AddOrUpdate(shot.Id, shot, (_, shot) => shot));
    }

    internal async Task<Shot> Get(Guid id)
    {
        return await Task.FromResult(_store[id]);
    }
    internal async Task<List<Shot>> Get()
    {
        return await Task.FromResult(_store.Values.ToList());
    }

    internal async Task Create(Shot shot)
    {
        _store.AddOrUpdate(shot.Id, shot, (_, shot) => shot);
        await Task.CompletedTask;
    }

    internal async Task Update(Shot shot)
    {
        _store.AddOrUpdate(shot.Id, shot, (_, shot) => shot);
        await Task.CompletedTask;
    }

    internal async Task Delete(Shot shot)
    {
        _store.Remove(shot.Id, out _);
        await Task.CompletedTask;
    }
}
