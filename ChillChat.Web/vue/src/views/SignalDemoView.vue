
<script setup lang="ts">
	import * as signalR from "@microsoft/signalr";
	//https://learn.microsoft.com/en-us/aspnet/core/signalr/javascript-client?view=aspnetcore-6.0&tabs=visual-studio


	//This might cause CORS trouble later
	let hubURL = "https://localhost:7069/chat/"
	let connection = new signalR.HubConnectionBuilder().withUrl(hubURL).build();

	connection.on("send", data => {
		console.log(data);
	});



	//FIXME: Use correct "packet" names
	connection.start().then(function() {

		
		document.querySelector("#send")?.addEventListener("click",function(){
			console.log("Click")
			let user = document.querySelector("#user")
			let message = document.querySelector("#message")
			let tstamp = Math.floor(Date.now() / 1000)
			try {
				connection.invoke("send",user,message,tstamp);
			} catch(err) {
				console.log(err)
			}
		});
	});

</script>



<template>

 <table>
	<thead>

		<tr>
			<th>username</th>
			<th>message</th>
			<th>time</th>
		</tr>
	</thead>
	<tbody>

		<tr>
			<td>a</td>
			<td>b</td>
			<td>c</td>
		</tr>
	</tbody>
</table>


<div class="box">
	<p>send message</p>
	<input value="testipekka" name="user" id="user">
	<input value="" placeholder="message" id="message">
	<button id="send">Send</button>
</div>


</template>

<style scoped></style>
