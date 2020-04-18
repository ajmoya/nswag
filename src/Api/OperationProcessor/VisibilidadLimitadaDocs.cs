using Api.Controllers;
using NSwag.Generation.Processors;
using NSwag.Generation.Processors.Contexts;

namespace Api.OperationProcessor
{
    public class VisibilidadLimitadaDocs : IOperationProcessor
    {
        public bool Process(OperationProcessorContext context) =>
            context.ControllerType != typeof(OtroLimitadoController);
    }
}