﻿namespace IncMusicStore.UnitTest
{
    #region << Using >>

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using IncMusicStore.Domain;
    using Incoding.MSpecContrib;
    using Machine.Specifications;

    #endregion

    [Subject(typeof(AlbumInGenresOptWhereSpec))]
    public class When_album_in_genres
    {
        #region Estabilish value

        static IQueryable<Album> fakeCollection;

        static List<Album> filterCollection;

        static string contains1;

        static string contains2;

        #endregion

        Establish establish = () =>
                                  {
                                      Func<string, Album> createEntity = (artistId) => Pleasure.MockStrictAsObject<Album>(mock => mock.SetupGet(r => r.Genre.Id).Returns(artistId));

                                      contains1 = Pleasure.Generator.String();
                                      contains2 = Pleasure.Generator.String();
                                      fakeCollection = Pleasure.ToQueryable(createEntity(contains1), createEntity(contains2), createEntity(Pleasure.Generator.String()));
                                  };

        Because of = () =>
                         {
                             filterCollection = fakeCollection
                                     .Where(new AlbumInGenresOptWhereSpec(new[] { contains1, contains2 }).IsSatisfiedBy())
                                     .ToList();
                         };

        It should_be_filter = () =>
                                  {
                                      filterCollection.Count.ShouldEqual(2);
                                      filterCollection[0].Genre.Id.ShouldEqual(contains1);
                                      filterCollection[1].Genre.Id.ShouldEqual(contains2);
                                  };

        It should_be_optional = () => fakeCollection
                                                  .Count(new AlbumInGenresOptWhereSpec(null).IsSatisfiedBy())
                                                  .ShouldEqual(3);
    }
}