using System.Collections.Generic;

namespace Zenject
{
    [NoReflectionBaking]
    public class DeclareSignalIdWithInterfacesRequireHandlerAsyncTickPriorityCopyBinder : DeclareSignalAsyncTickPriorityCopyBinder
    {
        private List<DeclareSignalIdRequireHandlerAsyncTickPriorityCopyBinder> declarations;
        
        public DeclareSignalIdWithInterfacesRequireHandlerAsyncTickPriorityCopyBinder(SignalDeclarationBindInfo signalBindInfo)
            : base(signalBindInfo)
        {
        }

        public DeclareSignalIdWithInterfacesRequireHandlerAsyncTickPriorityCopyBinder WithId(object identifier)
        {
            SignalBindInfo.Identifier = identifier;
            return this;
        }

        internal void AddDeclaration(DeclareSignalIdRequireHandlerAsyncTickPriorityCopyBinder declaration)
        {
            if (declarations == null)
                declarations = new List<DeclareSignalIdRequireHandlerAsyncTickPriorityCopyBinder>();
            
            declarations.Add(declaration);
        }
        
        public DeclareSignalAsyncTickPriorityCopyBinder RequireSubscriber()
        {
            SignalBindInfo.MissingHandlerResponse = SignalMissingHandlerResponses.Throw;

            for (var i = 0; i < declarations.Count; i++)
            {
                declarations[i].RequireSubscriber();
            }
            
            return this;
        }

        public DeclareSignalAsyncTickPriorityCopyBinder OptionalSubscriber()
        {
            SignalBindInfo.MissingHandlerResponse = SignalMissingHandlerResponses.Ignore;

            if (declarations != null)
            {
                for (var i = 0; i < declarations.Count; i++)
                {
                    declarations[i].OptionalSubscriber();
                }
            }

            return this;
        }

        public DeclareSignalAsyncTickPriorityCopyBinder OptionalSubscriberWithWarning()
        {
            SignalBindInfo.MissingHandlerResponse = SignalMissingHandlerResponses.Warn;

            if (declarations != null)
            {
                for (var i = 0; i < declarations.Count; i++)
                {
                    declarations[i].OptionalSubscriberWithWarning();
                }
            }

            return this;
        }
    }
}


