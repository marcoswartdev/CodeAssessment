# WongaCodeAssessment
My system infomation

- Windows 11
- Visual studio 2022 community edition
- Latest dotnet version 7.0.202
- Latest Docker version 20.10.23, build 7155243

How to run the project

- Step 1: Please make sure you have docker installed on your computer

- Step 2: Run the following command "docker-compose up -d" in a powershell terminal in the root of the solution. This will setup the docker container's for rabbitMQ, sender application and the receiver application.

- Step 3: Run "start powershell {docker start receiver-container -a -i} ; start powershell {docker start sender-container -a -i}" in your powershell terminal. This will start the reciever and sender container in two new powershell terminals and run them in attached interactive mode allowing you to input your name into the sender container terminal and seeing the response in the receiver container terminal. If this does not work make sure the rabbit container is running. It should already be running from step 2 but if this is not the case please start the rabbit container before running the sender and receiver.

If you experience any problems running this project on your machine or have any questions please feel free to reach out to me I would be happy to help.