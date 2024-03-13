.PHONY: build start stop logs test

# Build image
build:
	docker-compose build

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


