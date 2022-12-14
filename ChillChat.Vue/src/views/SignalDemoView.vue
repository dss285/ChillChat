<script setup lang="ts">
    import {ref, type Ref} from "vue"
    import { ChatHubService } from "@/services/chat.service";
    import { MessageSendModel } from "@/models/models";

	let hubURL = "https://localhost:7139/Chat/"
	
    let chatHubService = new ChatHubService(hubURL);
    // Changes to messagemodel at some point in future, now keep same
    let messages : Ref<MessageSendModel[]> = ref([]);
    let model = new MessageSendModel();

    await chatHubService.Start();
    
    chatHubService.RegisterCallback(chatHubService.schema.MESSAGE_POST.ReceiveMethod, (model : MessageSendModel) => {
        console.log(model)
        messages.value.push(model)
    })
    async function sendMessage() {
        await chatHubService.SendMessage(model);
    }
    
</script>

<template>
    <div>
        <input v-model="model.Message" placeholder="message">
        <button @click="sendMessage()">Send</button>
        <p>Messages</p>
        <p v-for="message in messages">{{message.User}} [{{message.TimeStamp}}]:{{message.Message}}</p>
		<hr>
		<p id="text"></p>
    </div>

</template>

<style scoped></style>