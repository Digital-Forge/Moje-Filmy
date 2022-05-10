<template>
    <div class="filmFrame">
        <div class="movieData">
            <p>{{ title }}</p>
            <p>{{ year }}</p>
        </div>
        <div class="showBottom">
            <button class="button-53" @click="showMovie">Show</button>
        </div>
        <div class="editBottom">
            <button class="button-53" style="background-color: yellow;" @click="editMovie">Edit</button>
        </div>
        <div class="deleteBottom">
            <button class="button-53" style="background-color: red;" @click="deleteMovie">Delete</button>
        </div>
        <div style="clear: both;"></div>
    </div>
</template>

<script>
import axios from 'axios'

export default {
    props: {
        movie: {
            type: Object,
            required: true,
        },
        apiURL: {
            type: String,
            required: true,
        }
    },
    data() {
        return {
            apiUrl: this.apiURL,
            id: this.movie.id,
            title: this.movie.title,
            year: this.movie.year
        }
    },
    methods: {
        showMovie() {
            alert(`add`);
        },
        editMovie() {
            alert(`edit`);
        },
        deleteMovie() {
            if (confirm('Are you sure you want to delete this movie?'))
            {
                axios.get(this.apiUrl, this.id);

                alert("Delete");
            }
        }
    }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.showBottom {
    margin-left: 15px;
}

.editBottom {
    float: left;
    margin-top: 20px;
    margin-left: 15px;
}

.deleteBottom {
    float: right;
    margin-right: 20px;
    margin-top: 13px;
}

.movieData {
    min-height: 140px;
    font-size: 30px;
}

.fixMargin
{
    margin-left: auto;
    margin-right: auto;
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
