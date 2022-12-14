<script setup lang="ts">
import { ChannelType } from "@/models/enums";
import { Channel, Server } from "@/models/models";
import { ref, type Ref } from "vue";
//import ServerComponent from "../../components/chat/ServerComponent.vue";

const servers : Server[] = [];
const chosenServer : Ref<Server|null> = ref(null);


for(let i = 0; i < 10; i++) {
    let server = new Server()
    server.Name = `${i} Lol`
    server.Channels = []
    for(let j = 0; j < 10; j++) {
        let channel = new Channel();
        channel.ChannelId = (i+1)*(j+1);
        channel.Name = `${server.Name} - ${i}x${j}`
        channel.ChannelType = ChannelType.TextChannel;
        server.Channels.push(channel);
    }
    servers.push(server);
}
let chooseServer =  (server : Server) => {
  console.log("server", server)
  chosenServer.value = server;
}


</script>


<template>
  <main>
    <div>
      <h2>Servers</h2>
      <ul >
        <li v-for="server of servers" @click="chooseServer(server)" style="display:inline-block;">
          | {{server.Name}} - {{server.Channels.length}} |
        </li>
      </ul>

    </div>
    <div v-if="chosenServer != null">
      <ServerComponent :server="chosenServer"></ServerComponent>
    </div>
  </main>
</template>
