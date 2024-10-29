# Application: Team Step Leaderboard

## Overview

This application provides an API for tracking and managing step counts for teams of employees. It leverages a .NET Core backend to handle data storage and retrieval, exposing RESTful endpoints to interact with the data.

## Features

### Team Management
- Create new teams
- Delete existing teams
- Retrieve a list of all teams

### Counter Management
- Create new counters for a specific team
- Delete existing counters
- Retrieve a list of all counters for a team

### Step Tracking
- Increment the value of a counter to record steps
- Retrieve the total step count for a team
- Retrieve a list of all teams and their total step counts

## API Endpoints

### Teams
- **GET /api/Teams:** Retrieves a list of all teams
- **POST /api/Teams:** Creates a new team
- **GET /api/Teams/{teamId}:** Retrieves a specific team
- **DELETE /api/Teams/{teamId}:** Deletes a specific team

### Counters
- **POST /api/Teams/{teamId}/counters:** Creates a new counter for a specific team
- **DELETE /api/Teams/counters/{counterId}:** Deletes a specific counter
- **POST /api/Teams/counters/{counterId}/increment:** Increments the value of a specific counter

## Getting Started

To get started with the Team Step Leaderboard application:

1. Clone the repository:
    ```bash
    git clone https://github.com/hamedahmed100/LeaderboardApp.git
    ```

2. Navigate to the project directory:
    ```bash
    cd LeaderboardApp
    ```

3. Build the application:
    ```bash
    dotnet build
    ```

4. Run the application:
    ```bash
    dotnet run
    ```

5. Access the API at `http://localhost/api/Teams`.

## Deploying on AWS EC2

If you want to deploy the project on AWS EC2, follow these steps:

1. **Connect to your EC2 instance** via SSH.

2. **Run the following script** to set up Docker and deploy the application:

    ```bash
    # Update package lists
    sudo apt update

    # Install Docker
    sudo apt install -y docker.io

    # Start Docker and enable it to run on startup
    sudo systemctl start docker
    sudo systemctl enable docker

    # Set variables
    REPO_URL="https://github.com/hamedahmed100/LeaderboardApp.git"
    APP_NAME="leaderboardapp"
    DOCKER_IMAGE="leaderboardapp-image"
    DOCKER_CONTAINER="leaderboardapp-container"

    # Stop and remove existing container if running
    sudo docker stop $DOCKER_CONTAINER || true
    sudo docker rm $DOCKER_CONTAINER || true

    # Clone or update the repository
    cd /home/ubuntu
    if [ -d "$APP_NAME" ]; then
      cd $APP_NAME
      git pull
    else
      git clone $REPO_URL $APP_NAME
      cd $APP_NAME
    fi

    # Build the Docker image
    sudo docker build -t $DOCKER_IMAGE -f LeaderboardApp/Dockerfile .

    # Run the container with specified ports
    sudo docker run -d --name $DOCKER_CONTAINER -p 8080:8080 -p 8081:8081 $DOCKER_IMAGE

    # Verify that the Container is Running
    sudo docker ps

    # Check docker logs
    sudo docker logs leaderboardapp-container
    ```

3. After running the script, you should be able to access the API on your EC2 instance's public IP at `http://<EC2_PUBLIC_IP>:8080/api/Teams`.

