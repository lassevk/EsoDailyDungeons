namespace EsoDailyDungeons.Core.Extensions
{
    internal class BootstrapperRegistry
    {
        private readonly HashSet<Type> _Bootstrappers = new();
        public bool IsFirstBootstrap(Type type) => _Bootstrappers.Add(type);
    }
}