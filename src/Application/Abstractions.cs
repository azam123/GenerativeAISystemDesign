using Domain;
namespace Application;
public interface IArchitectureAgent { Task<ArchitectureResult> GenerateAsync(ArchitectureRequest request,CancellationToken ct); }
public interface ICloudCostProvider { CloudProvider Provider {get;} Task<CostEstimate> EstimateAsync(CostEstimationRequest request,CancellationToken ct); }
public sealed record CostEstimationRequest(CloudProvider Provider,int ExpectedRequestsPerSecond,int StorageGb,int ComputeUnits,int DatabaseGb,string[] Regions);
public interface ISecurityAgent { Task<SecurityReview> ReviewAsync(string architecture,string[] frameworks,CancellationToken ct); }
public interface IInterviewAgent { Task<object> CoachAsync(string level,string scenario,CancellationToken ct); }
public interface IAdrGeneratorAgent { Task<Adr> GenerateAsync(string topic,string context,CancellationToken ct); }
public interface IKnowledgeAgent { Task<string> QueryAsync(string query,Dictionary<string,string>? metadata,CancellationToken ct); }
public interface IServiceBus { Task PublishAsync<T>(T message,CancellationToken ct); }
