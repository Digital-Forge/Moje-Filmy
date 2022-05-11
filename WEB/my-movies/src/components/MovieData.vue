<template>
    <div class="movieDataWrapper">
        <div class="movieDataContent">
            <div>
                <p>Title</p>
                <p v-if="!editStatus">{{ item.title }}</p>
                <input v-if="editStatus" type="text" v-model="item.title">
                <div v-if="editStatus || (item.year >= 1900 & item.year <= 2100)">
                    <p>Year production </p>
                    <p v-if="!editStatus">{{ item.year }}</p>
                    <input v-if="editStatus" @keypress="onlyNumber" type="text" maxlength="4" placeholder="1900 - 2100"
                        v-model="item.year">
                </div>

            </div>
            <div class="btnWrapper">
                <div class="btn">
                    <button class="button-53" style="background-color: grey;" @click="close">Close</button>
                </div>
                <div class="btn" v-if="editStatus">
                    <button class="button-53" style="background-color: green;" @click="save">Save</button>
                </div>
                <div style="clear: both;"></div>
            </div>
        </div>
    </div>
</template>

<script>
import axios from 'axios';
import useVuelidate from '@vuelidate/core'
import { required, between, numeric, minLength, maxLength } from '@vuelidate/validators'

export default {
    setup() {
        return {
            v$: useVuelidate()
        }
    },

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

    validations() {
        return {
            item: {
                title: {
                    required,
                    maxLength: maxLength(200),
                    minLength: minLength(1)
                },
                year: {
                    numeric,
                    between: between(1900, 2100),
                    maxLength: maxLength(0)
                }
            }
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

                if (this.item.title === "") {
                    alert("Title is required");
                    return;
                }

                if ((Number(this.item.year) < 1900 || Number(this.item.year) > 2100 ) 
                && (this.item.year.toString().length > 0 && Number(this.item.year) != 0 )) {
                    alert("Year isn't in range or empty");
                    return;
                }

                let responce;
                try {
                    if (this.item.id === 0) {
                        responce = await axios.post(`${this.apiURL}`, { id: 0, title: this.item.title, year: Number(this.item.year) });
                    } else {
                        responce = await axios.put(`${this.apiURL}`, { id: Number(this.item.id), title: this.item.title, year: Number(this.item.year) });
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
        },
        onlyNumber($event) {
            let keyCode = ($event.keyCode ? $event.keyCode : $event.which);
            if (keyCode < 48 || keyCode > 57) {
                $event.preventDefault();
            }
        }
    }

}
</script>

<style scoped>
p {
    margin-bottom: 0;
    margin-top: 25px;
}

input {
    font-size: 25px;
    width: 85%;
}

.btnWrapper {
    position: absolute;
    left: -10px;
    bottom: 16px;
    width: 100%;
}

.btn {
    float: right;
    margin: 10px;
    width: 44%;
}

.movieDataWrapper {
    position: fixed;
    top: 25%;
    left: -9px;
    right: 0;
    margin-left: auto;
    margin-right: auto;
    z-index: 10;

    justify-content: center;
    align-items: center;

    width: 475px;
    min-height: 320px;


    background-color: #652701;
    border-radius: 30px;
    padding: 8px;
}

.movieDataContent {
    padding: 10px;
    background-color: burlywood;
    border-radius: 30px;
    border: 2px dashed black;

    font-size: 30px;
    min-height: 300px;
}
</style>