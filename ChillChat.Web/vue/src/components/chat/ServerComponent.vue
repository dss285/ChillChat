<script setup lang="ts">
import type { Server } from '@/models/models';
import { ref, type Ref } from 'vue';
import ChannelComponent from './ChannelComponent.vue';


const props = defineProps<{
    server : Server
}>()

let selectedChannel : Ref<null|number> = ref(null);
</script>

<template>
  <main>
    <h4>{{server.Name}}</h4>

    <div>
      <h2>Channels</h2>
        <ul>
          <li style="display:inline-block" v-for="channel of server.Channels" @click="selectedChannel = channel.ChannelId">{{channel.Name}}</li>
        </ul>
        
        <div v-for="channel of server.Channels" :key="channel.ChannelId">
          <ChannelComponent v-if="channel.ChannelId == selectedChannel" :channel="channel" ></ChannelComponent>
        </div>

    </div>
  </main>
</template>
