# WongaCodeAssessment
How to run the project

Step 1: Please make sure you have docker installed on your computer (I have version 20.10.23, build 7155243 installed)

Step 2: Create a folder on your pc and add a docker-compose.yml file with the following contents below (when coping this please make sure the indentation is correct)

version: "3.2"
services:
  rabbitmq:
    image: rabbitmq:3-management
    container_name: 'console_app_rabbitmq_demo'
    ports:
        - 5672:5672
        - 15672:15672
    volumes:
        - ~/.docker-conf/rabbitmq/data/:/var/lib/rabbitmq/
        - ~/.docker-conf/rabbitmq/log/:/var/log/rabbitmq
    networks:
        - rabbitmq_go_net

networks:
  rabbitmq_go_net:
    driver: bridge

Step 3: run the follow command "docker-compose up" in the same directory as the docker-compose.yml file

Step 4: Visual studio has to be configured to run the both the ConsumerConsole and ProducerConsole projects simultaneously. To do this right click on the solution, then click on Configure Startup Projects. Then select the Multiple startup projects radio button and choose the start action for both projects and click apply.

Step 5: At the top next to the start button make sure to select the "Multiple Startup Projects" from the drop down and click the start button. If all goes well you should see two terminals that pop up. The one asking for you to enter your name and the other one will be blank until you have entered a name.

