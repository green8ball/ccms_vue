<template>
<body class="has-navbar-fixed-top">
<div>
<router-view/> 
</div>
</body>
</template>
  
<script lang="ts">
import { Component, Vue } from 'vue-property-decorator';
export default class App extends Vue {}
</script>

<style>
#app {
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale; 
}
</style>
