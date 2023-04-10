# WongaCodeAssessment
How to run the project

- Step 1: Please make sure you have docker installed on your computer (I have version 20.10.23, build 7155243 installed)

- Step 2: run the follow command "docker-compose up" in the root of the solution. This will setup the docker container for rabbitMQ

- Step 3: Visual studio has to be configured to run the both the Receiver and Sender projects simultaneously. To do this right click on the solution, then click on Configure Startup Projects. Then select the Multiple startup projects radio button and choose the start action for both projects and click apply.

- Step 4: At the top next to the start button make sure to select the "Multiple Startup Projects" from the drop down and click the start button. If all goes well you should see two terminals that pop up. The one asking for you to enter your name and the other one will be blank until you have entered a name.

