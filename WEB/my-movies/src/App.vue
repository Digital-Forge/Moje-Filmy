<template>
  <div class="outlineContainer">
    <div class="container">
      <MovieListApp />
    </div>
  </div>
</template>

<script>
import MovieList from './components/MovieList.vue'

export default {
  components: {
    MovieListApp: MovieList
}

}
</script>

<style scoped>
.container{
  width: 600px;
  padding: 20px;
  margin: 0px;
  background-color: darkslategray;
  border-left: 50px dashed white;
  border-right: 50px dashed white;
}
.outlineContainer{
  width: 750px;
  background-color: darkslategrey;
  padding-left: 30px;
  padding-right: 30px;
  margin-left:auto;
  margin-right:auto;
}
</style>
