from diagrams import Diagram, Cluster
from diagrams.custom import Custom
from diagrams.onprem.queue import RabbitMQ
from diagrams.azure.compute import AppServices;

with Diagram("Event Driven - Broker Topology", show=False, filename="big_picture_broker", direction="TB"):
    with Cluster("Kubernetes"):   
        with Cluster("cooking_container"):
            cooking_service = AppServices("CookingService")
        with Cluster("event_queue_container"):
            queue = RabbitMQ("bread queue")
        with Cluster("bread_container"):
            bread = AppServices("BreadService")
            #db_bread = Custom("db_bread", "../sql_lite.png")
        with Cluster("event_queue_container"):
            cheese_queue = RabbitMQ("cheese queue")
        with Cluster("cheese_container"):
            cheese = AppServices("CheeseService")
            #db_cheese = Custom("db_cheese", "../sql_lite.png")
        with Cluster("event_queue_container"):
            steak_queue = RabbitMQ("steak queue")
        with Cluster("steak_container"):
            steak = AppServices("SteakService")
            #db_steak = Custom("db_steak", "../sql_lite.png")
            
    #bread >> db_bread
    #cheese >> db_cheese
    #steak >> db_steak

    workers = [bread, cheese, steak]
    
    cooking_service >> queue >> bread >> cheese_queue >> cheese >> steak_queue >> steak