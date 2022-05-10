<template>
  <div>
    <div class="filmFrame">
      <h1>My Movies</h1>
      <div class="addBottom">
        <button class="button-53" @click="addMovie">Add</button>
      </div>
    </div>
    <MovieItem 
      v-for="item in movies" 
      :key="item.id" 
      :movie="item"
      />
  </div>
</template>

<script>
import MovieItem from './MovieItem.vue';

export default {
  data() {
    return{
      movies: [
        {id: 1, title: `Alibaba`, year : 1999},
        {id: 2, title: `Gensi`, year : 2002},
        {id: 3, title: `Sex`, year : 2050},
        {id: 4, title: `Forever`, year : 1950},
      ]
    }
  },
  components: {
    MovieItem
  },
  methods: {
    addMovie()
    {
      alert(`add`);
    },
  }
};
</script>

<style scoped>
.filmFrame{
    padding: 10px;
    margin-top: 30px;
    margin-left:auto;
    margin-right:auto;
    background-color: antiquewhite;
    height: 300px;
    width: 500px;
    border-radius: 40px;
    border: 5px solid black;
}

.addBottom {
    margin-left: 15px;
}

h1 {
  font-size: 90px;
}

.button-53 {
  background-color: #3DD1E7;
  border: 0 solid #E5E7EB;
  box-sizing: border-box;
  color: #000000;
  display: flex;
  font-family: ui-sans-serif,system-ui,-apple-system,system-ui,"Segoe UI",Roboto,"Helvetica Neue",Arial,"Noto Sans",sans-serif,"Apple Color Emoji","Segoe UI Emoji","Segoe UI Symbol","Noto Color Emoji";
  font-size: 1rem;
  font-weight: 700;
  justify-content: center;
  line-height: 1.75rem;
  padding: .75rem 1.65rem;
  position: relative;
  text-align: center;
  text-decoration: none #000000 solid;
  text-decoration-thickness: auto;
  width: 100%;
  max-width: 460px;
  position: relative;
  cursor: pointer;
  transform: rotate(-1.5deg);
  user-select: none;
  -webkit-user-select: none;
  touch-action: manipulation;
}

.button-53:focus {
  outline: 0;
}

.button-53:after {
  content: '';
  position: absolute;
  border: 1px solid #000000;
  bottom: 4px;
  left: 4px;
  width: calc(100% - 1px);
  height: calc(100% - 1px);
}

.button-53:hover:after {
  bottom: 2px;
  left: 2px;
}

@media (min-width: 768px) {
  .button-53 {
    padding: .75rem 3rem;
    font-size: 1.25rem;
  }
}
</style>
