<script setup lang="ts">
    import {ref, type Ref} from "vue"
    import { ChatHubService } from "@/services/chat.service";
    import { MessageSendModel } from "@/models/models";

	let hubURL = "https://localhost:7139/Chat/"
	
    let chatHubService = new ChatHubService(hubURL);
    // Changes to messagemodel at some point in future, now keep same
    let messages : Ref<MessageSendModel[]> = ref([]);
    let model = new MessageSendModel();

    
    chatHubService.RegisterCallback("ReceiveMessage", (model : MessageSendModel) => {
        console.log(model)
        messages.value.push(model)
    })
    function sendMessage() {
        chatHubService.SendMessage(model);
    }
    await chatHubService.Start();
</script>

<template>
    <div>
        <input v-model="model.User" placeholder="username">
        <input v-model="model.Message" placeholder="message">
        <button @click="sendMessage()">Send</button>
        <p>MessageASDASs</p>
        <p v-for="message in messages">{{message.User}} [{{message.TimeStamp}}]:{{message.Message}}</p>
		<hr>
		<p id="text"></p>
    </div>

</template>

<style scoped></style>