<script setup lang="ts">
import { Channel, Message } from '@/models/models';
import MessageComponent from './MessageComponent.vue';


const props = defineProps<{
    channel : Channel
}>()


let messages : Message[] = []
for(let i = 0; i<20;i++) {
    let message = new Message();
    message.Content = `${i} : Moi`
    message.ChannelId = props.channel.ChannelId;
    messages.push(message)
}
</script>

<template>
  <main>
    <h2>{{channel.Name}}</h2>
    <div>
        <MessageComponent :message="message" v-for="message of messages"></MessageComponent>
    </div>
  </main>
</template>
