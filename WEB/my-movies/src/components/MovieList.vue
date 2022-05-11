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
      :apiURL="apiURL" 
      @showMovie="handlerShowMovie"
      @editMovie="handlerEditMovie" 
      @refresh="handlerRefresh" />
    <MovieData 
      v-if="modale.open" 
      :apiURL="apiURL" 
      :editStatus="modale.edit"
      :movie="modale.dataBuff"
      @closeModal="handlerCloseModal" 
      @save="handlerRefresh" />
  </div>
</template>

<script>
import axios from 'axios';
import MovieItem from './MovieItem.vue';
import MovieData from './MovieData.vue';

export default {
  props: {
    apiURL: {
      type: String,
      required: true,
    }
  },

  data() {
    return {
      lockProcessing: false,
      modale: {
        open: false,
        edit: false,
        dataBuff: null,
      },
      movies: []
    }
  },

  components: {
    MovieItem,
    MovieData
  },

  methods: {
    addMovie() {
      if (!this.lockProcessing) {
        this.lockProcessing = true;
      this.modale.edit = true;
      this.modale.dataBuff = null;
      this.modale.open = true;
      }      
    },
    handlerShowMovie(movie) {
      if (!this.lockProcessing) {
        this.lockProcessing = true;
      this.modale.edit = false;
      this.modale.dataBuff = movie;
      this.modale.open = true;
      }      
    },
    handlerEditMovie(movie) {
      if (!this.lockProcessing) {
        this.lockProcessing = true;
      this.modale.edit = true;
      this.modale.dataBuff = movie;
      this.modale.open = true;
      }      
    },
    async handlerRefresh() {
      this.handlerCloseModal();
      this.lockProcessing = true;

      try {
        const responce = await axios.get(`${this.apiURL}`);
        console.log(responce.status);
        this.movies = responce.data
      } catch (error) {
        console.log(error);
        alert("Sorry, refresh operation failed");
      }

      this.lockProcessing = false;
    },
    handlerCloseModal() {
      this.modale.open = false;
      this.modale.dataBuff = null
      this.lockProcessing = false;
    }
  },
  
  mounted() {
    this.handlerRefresh();
  },
};
</script>

<style scoped>
.filmFrame {
  padding: 10px;
  margin-top: 30px;
  margin-left: auto;
  margin-right: auto;
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
</style>
