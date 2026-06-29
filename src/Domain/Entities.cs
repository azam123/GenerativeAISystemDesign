namespace Domain;
public enum UserRole { Admin, Architect, Reviewer, Viewer }
public enum CloudProvider { Azure, Aws, Gcp }
public sealed record ArchitectureRequest(string BusinessRequirements,string FunctionalRequirements,string NonFunctionalRequirements,string ExpectedScale,string BudgetConstraints);
public sealed record DiagramSet(string ComponentMermaid,string SequenceMermaid,string DataFlowMermaid,string InfrastructureMermaid,string ReactFlowJson);
public sealed record ArchitectureResult(string HighLevelArchitecture,string DetailedArchitecture,DiagramSet Diagrams,IReadOnlyList<string> Recommendations);
public sealed record CostEstimate(decimal MonthlyEstimate,decimal AnnualEstimate,IReadOnlyDictionary<string,decimal> Breakdown,IReadOnlyList<string> Optimizations);
public sealed record SecurityReview(int RiskScore,IReadOnlyList<string> Findings,IReadOnlyList<string> Remediations,IReadOnlyDictionary<string,bool> ComplianceChecklist);
public sealed class Adr { public Guid Id {get;set;}=Guid.NewGuid(); public int Version {get;set;}=1; public string Title {get;set;}=""; public string Context {get;set;}=""; public string Problem {get;set;}=""; public string Constraints {get;set;}=""; public string Decision {get;set;}=""; public string Consequences {get;set;}=""; public string Alternatives {get;set;}=""; public string References {get;set;}=""; public DateTimeOffset CreatedAt {get;set;}=DateTimeOffset.UtcNow; }
