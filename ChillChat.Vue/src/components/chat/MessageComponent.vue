<script setup lang="ts">
import type { Message } from '@/models/models';


const props = defineProps<{
    message : Message
}>()
</script>

<template>
  <main>
    <div>
        <h4>{{message.ChannelId}}</h4>
        <p>{{message.Content}}</p>
    </div>
  </main>
</template>
