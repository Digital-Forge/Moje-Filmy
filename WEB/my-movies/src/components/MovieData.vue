<template>
    <div class="movieDataWrapper">
        <p>Title</p>
        <p v-if="!editStatus">{{ item.title }}</p>
        <input v-if="editStatus" type="text" v-model="item.title">
        <p>Year production</p>
        <p v-if="!editStatus">{{ item.year }}</p>
        <input v-if="editStatus" type="text" v-model="item.year">
        <button v-if="editStatus" @click="save">Save</button>
        <button @click="close">Close</button>
    </div>
</template>

<script>
import axios from 'axios';

export default {
    props: {
        movie: {
            type: Object,
        },
        editStatus: {
            type: Boolean,
            default: false
        },
        apiURL: {
            type: String,
            required: true
        }
    },

    data() {
        return {
            item: {
                id: this.movie?.id ?? 0,
                title: this.movie?.title ?? ``,
                year: this.movie?.year ?? ``
            },
        }
    },

    mounted() {
        this.item.id = this.movie?.id ?? 0;
        this.item.title = this.movie?.title ?? ``;
        this.item.year = this.movie?.year ?? ``
    },

    methods: {
        async save() {
            if (this.editStatus) {
                let responce;
                try {
                    if (this.item.id === 0) {
                        responce = await axios.post(`${this.apiURL}`, {id: 0, title: this.item.title, year: Number(this.item.year)});
                    } else {                        
                        responce = await axios.put(`${this.apiURL}`, {id: Number(this.item.id), title: this.item.title, year: Number(this.item.year)});
                    }
                    console.log(responce.status)
                    this.$emit('save');
                } catch (error) {
                    console.log(error);
                    alert("Sorry, save operation failed");
                }
            }
        },
        close() {
            this.$emit('closeModal');
        }
    }

}
</script>

<style scoped>
.movieDataWrapper {
    max-width: 100%;
    position: fixed;
    top: 0;
    left: 0;
    display: flex;
    align-items: center;
    padding: 50px;
}
</style>