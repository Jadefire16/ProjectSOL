using UnityEngine;

namespace JadesToolkit.StateOfLife.Chronos.Updating
{
    public class UpdateHandler : MonoBehaviour, IUpdateServiceProvider
    {
        IUpdateResolver resolver;
        public IUpdateResolver UpdateResolver => resolver;
        public void SetUpdateResolver(IUpdateResolver resolver) => this.resolver = resolver;
        public IUpdateResolver GetUpdateResolver() => resolver;

        public UpdateHandler(IUpdateResolver resolver)
        {
            this.resolver = resolver;
        }
        public void Update()
        {
            resolver.Resolve<IUpdateCycle>();
        }
        public void FixedUpdate()
        {
            resolver.Resolve<IFixedCycle>();
        }
        public void LateUpdate()
        {
            resolver.Resolve<ILateCycle>();
        }
    }
}