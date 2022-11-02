<script setup lang="ts">
    import {ref} from "vue"
	import * as signalR from "@microsoft/signalr";

    const props = defineProps<{
        username: string,
        message: string,
        timestamp: string,
        connection: string,
    }>()

	let hubURL = "https://localhost:7139/Chat/"
	let connection = new signalR.HubConnectionBuilder().withUrl(hubURL).withAutomaticReconnect().build();

    connection.start().then(function() {})


    let username = ref("TeppoTesti")
    let message = ref("")
    let timestamp = ref("")

    function MessageSend() {
        let tstamp = Math.floor(Date.now() / 1000)

		try {
			connection.invoke("MessageSent",username.value,message.value,tstamp);
			console.log("Sent")
		} catch(err) {
			console.log(err)
		}
    }

	connection.on("ReceiveMessage", (user, message) => {
        console.log("Message recieved: "+user+" "+message)
		document.querySelector("#text").innerHTML += "Message recieved: "+user+" "+message+"<br>"
	});
</script>

<template>
    <div>
        <input v-model="username" @change="username=username" placeholder="username">
        <input v-model="message" placeholder="message">
        <button @click="MessageSend()">Send</button>
        <p>Message: {{ message }}</p>
		<hr>
		<p id="text"></p>
    </div>

</template>

<style scoped></style>