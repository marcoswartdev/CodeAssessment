# WongaCodeAssessment
How to run the project

- Step 1: Please make sure you have docker installed on your computer (I have version 20.10.23, build 7155243 installed)

- Step 2: Run the following command "docker-compose up -d" in a powershell terminal in the root of the solution. This will setup the docker container's for rabbitMQ, sender application and the receiver application.

- Step 3: Run the following command "start powershell {docker start receiver-container -a -i}" in your powershell terminal. This will start the receiver docker container and attach to your terminal.

- Step 4: Run the following command "start powershell {docker start sender-container -a -i}" in your powershell terminal. This will start the sender docker container and attach to your terminal. It will prompt you to enter your name. Once you have entered your name it will be displayed in the receiver container's terminal that we have opened in step 3.


