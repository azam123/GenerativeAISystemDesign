# AI Solution Architect Assistant

Production-ready SaaS reference implementation for AI-assisted enterprise architecture.

## Stack
- Next.js 15, TypeScript, Tailwind, React Query, Mermaid, React Flow
- ASP.NET Core 9 Web API using Clean Architecture, CQRS-ready boundaries, MediatR-ready application layer
- PostgreSQL, Qdrant, Redis, Azure OpenAI / Semantic Kernel abstraction
- Docker Compose, Terraform, GitHub Actions

## Local development
```bash
docker compose -f infra/docker/docker-compose.yml up --build
```

## API
See `docs/api/openapi.md` and `postman/AI-Solution-Architect-Assistant.postman_collection.json`.

## Security
JWT auth with Azure Entra ID configuration, RBAC roles Admin, Architect, Reviewer, Viewer, audit logging, TLS-first deployment guidance, and API key management placeholders.
