<template>
    <div class="filmFrame">
        <div class="movieData">
            <p>{{ movie.title }}</p>
            <p v-if="movie.year >= 1900 & movie.year <=2100">{{ movie.year }}</p>
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

    methods: {
        showMovie() {
            this.$emit('showMovie', this.movie);
        },
        editMovie() {
            this.$emit('editMovie', this.movie);
        },
        async deleteMovie() {
            if (confirm('Are you sure you want to delete this movie?'))
            {
                try {
                    const responce = await axios.delete(`${this.apiURL}/${Number(this.movie.id)}`);
                    console.log(responce.status)
                    this.$emit('refresh');
                } catch (error) {
                    console.log(error);
                    alert("Sorry, this operation failed");
                }
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
</style>
