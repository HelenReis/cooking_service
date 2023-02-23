from diagrams import Diagram, Cluster
from diagrams.custom import Custom
from diagrams.onprem.queue import RabbitMQ
from diagrams.azure.compute import AppServices;

with Diagram("Event Driven - Mediator Topology", show=False, filename="big_picture_mediator", direction="TB"):
    with Cluster("Kubernetes"):   
        with Cluster("cooking_container"):
            cooking_service = AppServices("CookingService")
        with Cluster("event_queue_container"):
            queue = RabbitMQ("cooking_queue")
        with Cluster("bread_container"):
            bread = AppServices("BreadService")
        with Cluster("cheese_container"):
            cheese = AppServices("CheeseService")
        with Cluster("steak_container"):
            steak = AppServices("SteakService")
        with Cluster("event_queue_waiter_container", direction="LR"):
            waiter_queue = RabbitMQ("waiter_queue")
        with Cluster("waiter_service", direction="LR"):
            waiter = AppServices("WaiterService")
            db_waiter = Custom("db_waiter", "../sql_lite.png")

    workers = [bread, cheese, steak]
    
    cooking_service >> queue >> workers
    workers >> waiter_queue >> waiter