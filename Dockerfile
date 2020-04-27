FROM node:latest AS build

# Install node modules
WORKDIR /src

COPY package*.json ./
RUN npm install

# Build the project
COPY . .
RUN npm run build

FROM node:latest AS run

# Copy the built app
WORKDIR /app

COPY --from=build /src/build ./build
COPY --from=build /src/node_modules ./node_modules
COPY --from=build /src/server.js ./

ENTRYPOINT ["node", "./server.js"]

