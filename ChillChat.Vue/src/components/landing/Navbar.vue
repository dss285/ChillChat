<template>


<nav class="navbar navbar-expand-lg navbar-dark bg-dark">
    <div class="container-fluid">
        <a class="navbar-brand" href="#">ChillChat</a>
        <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
            <span class="navbar-toggler-icon"></span>
        </button>

        <div class="collapse navbar-collapse" id="navbarSupportedContent">
            <ul class="navbar-nav me-auto mb-2 mb-lg-0">
                <li class="nav-item">
                    <RouterLink class="nav-link active" to="/">Home</RouterLink>
                </li>

                <li class="nav-item">
                    <RouterLink class="nav-link" to="/chat">Chat</RouterLink>
                </li>

                <li class="nav-item">
                    <RouterLink class="nav-link" to="/services">Services</RouterLink>
                </li>

                <li class="nav-item dropdown">
                    <a class="nav-link dropdown-toggle" href="#" role="button" data-bs-toggle="dropdown" aria-expanded="false">
                        Debug
                    </a>
                    <ul class="dropdown-menu">
                        <li><RouterLink class="dropdown-item" to="/signaldemo">SignalR Demo</RouterLink></li>
                        <li><a class="dropdown-item" href="#">lorem ipsum</a></li>
                        <li><hr class="dropdown-divider"></li>
                        <li><a class="dropdown-item" href="#">Cookies for placeholder!</a></li>
                    </ul>
                </li>
            </ul>

            <form class="d-flex" role="search">
                <router-link class="btn btn-outline-success btn-full" to="/login">Login</router-link>
            </form>
        </div>
    </div>
</nav>


</template>