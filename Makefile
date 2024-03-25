.PHONY: build start stop logs test generate-migration run-migrations

# Build image
build:
	docker-compose build --build-arg UID=$$(id -u) --build-arg GID=$$(id -g)

# Start multi-container application
start:
	docker-compose up -d

# Stop containers
stop:
	docker-compose down

# Show main backend application logs
logs:
	docker-compose logs -f backend-app

# Run unit tests
test:
	docker-compose run --rm backend-app dotnet test

# Generate migrations base on model changes
generate-migration:
	docker-compose exec backend-app dotnet ef migrations add $(name) --project src/Backend.Infrastructure --startup-project src/Backend.Api

# Run all migrations
run-migrations:
	docker-compose exec backend-app dotnet ef database update --project src/Backend.Infrastructure --startup-project src/Backend.Api


