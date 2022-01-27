using UnityEngine;

namespace JadesToolkit.Experimental.StateMachine
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
            resolver.Resolve<IUpdate>();
        }
        public void FixedUpdate()
        {
            resolver.Resolve<IFixedUpdate>();
        }
        public void LateUpdate()
        {
            resolver.Resolve<ILateUpdate>();
        }
    }
}