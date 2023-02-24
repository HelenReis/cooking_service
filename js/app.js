const amqp = require("amqplib");
const express = require('express');
const app = express();

app.use(express.static('./src'));

app.get('/', function(req, res) {
  res.sendFile('/index.html');
});

app.listen(3000, function() {
  console.log('Server running on port 3000');
});

async function listenToQueue() {
    const connection = await amqp.connect('amqp://localhost');
    const channel = await connection.createChannel();
    await channel.assertQueue("bread_queue", { durable: false });

    channel.consume("bread_queue", (message) => {
      console.log("chegou mensagem");
        console.log(message.content.toString());
    });
}