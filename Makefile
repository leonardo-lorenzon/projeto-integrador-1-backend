.PHONY: build start stop logs test migration-generate migrations-run migration-revert-to

# Build image
build:
	docker compose build --build-arg UID=$$(id -u) --build-arg GID=$$(id -g)

# Start multi-container application
start:
	docker compose up

# Stop containers
stop:
	docker compose down

# Show main backend application logs
logs:
	docker compose logs -f backend-app

# Run unit tests
test:
	docker compose run --rm backend-app dotnet test

# Generate migrations base on model changes
migration-generate:
	docker compose exec backend-app dotnet ef migrations add $(name) --project src/Backend.Infrastructure --startup-project src/Backend.Api

# Run all migrations
migrations-run:
	docker compose exec backend-app dotnet ef database update --project src/Backend.Infrastructure --startup-project src/Backend.Api

# Revert applied migrations to the specified migration
# Do not revert migrations that are already in master branch
migration-revert-to:
	docker compose exec backend-app dotnet ef database update $(name) --project src/Backend.Infrastructure --startup-project src/Backend.Api
