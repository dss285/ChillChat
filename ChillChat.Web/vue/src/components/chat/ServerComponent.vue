<script setup lang="ts">
import type { Server } from '@/models/models';
import ChannelComponent from './ChannelComponent.vue';


const props = defineProps<{
    server : Server
}>()
</script>

<template>
  <main>
    <p>asd</p>
    <h4>{{server.Name}}</h4>

    <div>
        <ChannelComponent :channel="channel" v-for="channel of server.Channels"></ChannelComponent>

    </div>
  </main>
</template>
